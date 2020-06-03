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

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class ReportService {

    private final ReportRepository reportRepository;

    public RentResponse getReportFile(Date date) {
        Report report;
        if (date != null) {
            report = reportRepository.findByCreationDateBetween(ZonedDateTime.from(date.toInstant().atZone(ZoneId.systemDefault())).truncatedTo(ChronoUnit.DAYS)
                    .with(LocalTime.MIDNIGHT), ZonedDateTime.from(date.toInstant().atZone(ZoneId.systemDefault())).with(LocalTime.MIDNIGHT)
                    .plusHours(23).plusMinutes(59).plusSeconds(59))
                    .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.REPORT_NOT_FOUND));
        } else {
            Date now = new Date();
            report = reportRepository.findByCreationDateBetween(ZonedDateTime.from(now.toInstant().atZone(ZoneId.systemDefault()))
                    .with(LocalTime.MIDNIGHT), ZonedDateTime.from(now.toInstant().atZone(ZoneId.systemDefault())))
                    .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.REPORT_NOT_FOUND));
        }
        File file = new File(report.getPath());
        RentResponse rentResponse = new RentResponse();
        try {
            InputStream in = new FileInputStream(file);
            rentResponse.setFile(IOUtils.toByteArray(in));
            rentResponse.setFileName(file.getName());
        } catch (IOException e) {
            log.info("File not found, error = " + e);
        }
        return rentResponse;
    }
}
