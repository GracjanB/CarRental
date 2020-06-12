package pl.bucior.carrental.model.request;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.extern.log4j.Log4j2;
import org.springframework.web.multipart.MultipartFile;

import javax.validation.constraints.NotNull;
import java.io.Serializable;

@Builder
@Data
@Log4j2
@AllArgsConstructor
public class FileUploadForm implements Serializable {

    @NotNull
    private String vin;

    @NotNull
    private MultipartFile file;

}