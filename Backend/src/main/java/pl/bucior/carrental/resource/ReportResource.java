package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.model.response.RentResponse;
import pl.bucior.carrental.service.ReportService;
import springfox.documentation.annotations.ApiIgnore;

import javax.servlet.http.HttpServletResponse;
import java.security.Principal;
import java.util.Date;

@Log4j2
@RestController
@RequiredArgsConstructor
@RequestMapping("report")
public class ReportResource {

    private final ReportService reportService;

    @GetMapping(value = "rent", produces = MediaType.APPLICATION_OCTET_STREAM_VALUE)
    public ResponseEntity<byte[]> getAllReportByDate(@RequestParam(name = "startDate")
                                                     @DateTimeFormat(pattern = "yyyy-MM-dd") Date startDate,
                                                     @RequestParam(name = "endDate")
                                                     @DateTimeFormat(pattern = "yyyy-MM-dd") Date endDate,
                                                     @ApiIgnore Principal principal,
                                                     @ApiIgnore HttpServletResponse response) {
        RentResponse rentResponse = reportService.getReportFile(startDate, endDate, principal);
        if (rentResponse != null && rentResponse.getFile() != null) {
            response.setHeader("Content-Disposition", String.format("attachment; filename=%s", rentResponse.getFileName()));
            return ResponseEntity.ok(rentResponse.getFile());
        }
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }


}
