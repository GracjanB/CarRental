package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.apache.poi.util.IOUtils;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.jpa.Report;
import pl.bucior.carrental.model.response.RentResponse;
import pl.bucior.carrental.repository.ReportRepository;

import javax.transaction.Transactional;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.time.LocalTime;
import java.time.ZoneId;
import java.time.ZonedDateTime;
import java.time.temporal.ChronoUnit;
import java.util.Date;
import java.util.Optional;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class ReportService {

    private final ReportRepository reportRepository;

    public RentResponse getReportFile(Date date) throws IOException {
        Optional<Report> reportOpt;
        if (date != null) {
            reportOpt = reportRepository.findByCreationDateBetween(ZonedDateTime.from(date.toInstant().atZone(ZoneId.systemDefault())).truncatedTo(ChronoUnit.DAYS)
                    .with(LocalTime.MIDNIGHT), ZonedDateTime.from(date.toInstant().atZone(ZoneId.systemDefault())));
        } else {
            Date now = new Date();
            reportOpt = reportRepository.findByCreationDateBetween(ZonedDateTime.from(now.toInstant().atZone(ZoneId.systemDefault()))
                    .with(LocalTime.MIDNIGHT), ZonedDateTime.from(now.toInstant().atZone(ZoneId.systemDefault())));
        }
        Report report = reportOpt.orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.REPORT_NOT_FOUND));
        File file = new File(report.getPath());
        InputStream in = new FileInputStream(file);
        RentResponse rentResponse = new RentResponse();
        rentResponse.setFile(IOUtils.toByteArray(in));
        rentResponse.setFileName(file.getName());
        return rentResponse;
    }
}
