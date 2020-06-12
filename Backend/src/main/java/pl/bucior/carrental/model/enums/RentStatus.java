package pl.bucior.carrental.model.enums;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;

@Getter
@NoArgsConstructor
@AllArgsConstructor
public enum RentStatus {
    CREATED("Wypożyczono"), RENTED("Wypożyczono"), DELAYED("Wypożyczenie opóźnione"),
    RETURNED("Zwrócono"), CANCELLED("Anulowano");


    private String value;
}
