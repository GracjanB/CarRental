package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pl.bucior.carrental.model.request.FileUploadForm;
import pl.bucior.carrental.service.CarPhotoService;

import javax.validation.Valid;

@RestController
@RequiredArgsConstructor
@RequestMapping("carPhoto")
public class CarPhotoResource {
    private final CarPhotoService carPhotoService;

    @PostMapping(consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public ResponseEntity<Void> sendImage(
            @Valid FileUploadForm request
    ) {
        carPhotoService.saveFile(request);
        return new ResponseEntity<>(HttpStatus.CREATED);
    }

    @GetMapping(produces = MediaType.IMAGE_PNG_VALUE)
    public ResponseEntity<byte[]> getImage(@RequestParam(name = "photoId") Long id) {
        return ResponseEntity.ok(carPhotoService.getFile(id));
    }

    @DeleteMapping
    public ResponseEntity<Void> deleteImage(@RequestParam(name = "photoId") Long id) {
        carPhotoService.deleteFile(id);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }

}
