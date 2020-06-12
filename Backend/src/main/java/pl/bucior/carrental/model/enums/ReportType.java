package pl.bucior.carrental.model.enums;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;

@Getter
@NoArgsConstructor
@AllArgsConstructor
public enum ReportType {
    RENT("Wypożyczenia");

    private String value;
}
