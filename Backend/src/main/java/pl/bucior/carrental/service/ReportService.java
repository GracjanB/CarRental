package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.apache.poi.util.IOUtils;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.jpa.Report;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.response.RentResponse;
import pl.bucior.carrental.repository.ReportRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.security.Principal;
import java.time.LocalTime;
import java.time.ZoneId;
import java.time.ZonedDateTime;
import java.time.temporal.ChronoUnit;
import java.util.Date;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class ReportService {

    private final ReportRepository reportRepository;
    private final UserRepository userRepository;
    private final ReportGenerationService reportGenerationService;


    public RentResponse getReportFile(Date startDate, Date endDate, Principal principal) {
        User employee = userRepository.findByEmail(principal.getName())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND));
        Report report = reportGenerationService.generateRentReport(ZonedDateTime
                        .from(startDate.toInstant().atZone(ZoneId.systemDefault())).truncatedTo(ChronoUnit.DAYS)
                        .with(LocalTime.MIDNIGHT),
                ZonedDateTime.from(endDate.toInstant().atZone(ZoneId.systemDefault())).with(LocalTime.MIDNIGHT)
                        .plusHours(23).plusMinutes(59).plusSeconds(59));
        if (report == null) {
            throw new WsizException("Cannot create report", HttpStatus.CONFLICT, ErrorCode.REPORT_NOT_FOUND);
        }
        report.setUserId(employee.getId());
        reportRepository.save(report);
        File file = new File(report.getPath());
        RentResponse rentResponse = new RentResponse();
        try {
            InputStream in = new FileInputStream(file);
            rentResponse.setFile(IOUtils.toByteArray(in));
            rentResponse.setFileName(file.getName());
            report.setPath(null);
            log.info("File deleted successfully, path = " + file.getPath());
        } catch (IOException e) {
            log.info("File not found, error = " + e);
        }
        return rentResponse;
    }
}
