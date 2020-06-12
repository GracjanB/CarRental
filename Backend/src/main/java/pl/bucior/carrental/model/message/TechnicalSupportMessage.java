package pl.bucior.carrental.model.message;

import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
public class TechnicalSupportMessage {

    private List<String> emails = new ArrayList<>();
    private String registerPlate;
    private String address;
}
