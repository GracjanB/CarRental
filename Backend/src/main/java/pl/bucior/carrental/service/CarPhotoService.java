package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.CarPhoto;
import pl.bucior.carrental.model.request.FileUploadForm;
import pl.bucior.carrental.repository.CarPhotoRepository;
import pl.bucior.carrental.repository.CarRepository;

import javax.transaction.Transactional;
import java.io.IOException;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class CarPhotoService {

    private final CarPhotoRepository carPhotoRepository;
    private final CarRepository carRepository;

    public void saveFile(FileUploadForm request) {
        try {
            Car car = carRepository.findById(request.getVin())
                    .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.CAR_NOT_FOUND));
            CarPhoto carPhoto = carPhotoRepository.save(CarPhoto.builder()
                    .photo(request.getFile().getBytes())
                    .build());
            car.setCarPhoto(carPhoto);
        } catch (IOException e) {
            log.error("Unable to save file, error = " + e);
        }
    }

    public byte[] getFile(Long id) {
        return carPhotoRepository.findById(id)
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.CAR_PHOTO_NOT_FOUND)).getPhoto();
    }

}