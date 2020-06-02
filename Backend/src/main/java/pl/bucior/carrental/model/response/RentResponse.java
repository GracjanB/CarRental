package pl.bucior.carrental.model.response;

import lombok.Data;

import java.io.Serializable;

@Data
public class RentResponse implements Serializable {
    private String fileName;
    private byte[] file;
}
