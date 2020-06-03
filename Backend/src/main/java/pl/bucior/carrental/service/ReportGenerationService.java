package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.mapper.RentMapper;
import pl.bucior.carrental.model.dto.RentDto;
import pl.bucior.carrental.model.enums.ReportType;
import pl.bucior.carrental.model.jpa.Report;
import pl.bucior.carrental.repository.RentRepository;
import pl.bucior.carrental.repository.ReportRepository;

import javax.transaction.Transactional;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class ReportGenerationService {

    private final RentRepository rentRepository;
    private final ReportRepository reportRepository;

    public void checkDirectoryCreation() {
        if (new File("report/rent").mkdirs()) {
            log.info("Directory was created.");
        }
    }


    public Report generateRentReport(ZonedDateTime start, ZonedDateTime end) {
        checkDirectoryCreation();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss");
        Workbook workbook = new XSSFWorkbook();
        Sheet sheet = workbook.createSheet("Wypożyczenia");
        Font headerFont = workbook.createFont();
        headerFont.setBold(true);
        headerFont.setFontHeightInPoints((short) 14);
        headerFont.setColor(IndexedColors.RED.getIndex());

        CellStyle headerCellStyle = workbook.createCellStyle();
        headerCellStyle.setFont(headerFont);
        Row headerRow = sheet.createRow(0);

        List<String> columns = new ArrayList<>();
        columns.add("ID");
        columns.add("Status");
        columns.add("Miasto startowe wypożyczenia");
        columns.add("Miasto końcowe wypożyczenia");
        columns.add("VIN pojazdu");
        columns.add("Sugerowana cena wynajmu");
        columns.add("Końcowa cena wynajmu");
        columns.add("Końcowa cena wynajmu");
        columns.add("Wysokość kaucji");
        columns.add("Data wypożczenia");
        columns.add("Data oddania");
        columns.add("Stan licznika przed(KM)");
        columns.add("Stan licznika po(KM)");

        for (int i = 0; i < columns.size(); i++) {
            Cell cell = headerRow.createCell(i);
            cell.setCellValue(columns.get(i));
            cell.setCellStyle(headerCellStyle);
        }
        List<RentDto> rentDtos = rentRepository.findAll().stream().map(RentMapper.INSTANCE::toDto).collect(Collectors.toList());
        int rowNum = 1;
        for (RentDto rent : rentDtos) {
            Row row = sheet.createRow(rowNum++);
            int cellNum = 0;
            row.createCell(cellNum++).setCellValue(rent.getId());
            row.createCell(cellNum++).setCellValue(rent.getStatus().getValue());
            row.createCell(cellNum++).setCellValue(rent.getAgencyCity());
            row.createCell(cellNum++).setCellValue(rent.getTargetAgencyCity() != null ? rent.getTargetAgencyCity() : "");
            row.createCell(cellNum++).setCellValue(rent.getCarVin());
            row.createCell(cellNum++).setCellValue(rent.getCalculatedPrice() != null ? rent.getCalculatedPrice().toPlainString() : "");
            row.createCell(cellNum++).setCellValue(rent.getFinalPrice() != null ? rent.getFinalPrice().toPlainString() : "");
            row.createCell(cellNum++).setCellValue(rent.getDeposit() != null ? rent.getDeposit().toPlainString() : "");
            row.createCell(cellNum++).setCellValue(rent.getRentStartDate().format(formatter));
            row.createCell(cellNum++).setCellValue(rent.getRentEndDate().format(formatter));
            row.createCell(cellNum++).setCellValue(rent.getStartMileage());
            row.createCell(cellNum).setCellValue(rent.getEndMileage() != null ? rent.getEndMileage().toString() : "");
        }
        for (int i = 0; i < columns.size(); i++) {
            sheet.autoSizeColumn(i);
        }
        try {
            String path = String.format("report/rent/rent_report_%s.xlsx", start.format(DateTimeFormatter.ofPattern("dd-MM-yyyy")));
            FileOutputStream fileOut = new FileOutputStream(String.format("report/rent/rent_report_%s.xlsx", start.format(DateTimeFormatter.ofPattern("dd-MM-yyyy"))));
            workbook.write(fileOut);
            fileOut.close();
            return Report.builder()
                    .path(path)
                    .reportType(ReportType.RENT)
                    .build();

        } catch (IOException e) {
            log.error(e);
        }
        return null;
    }
}
