package pl.bucior.carrental.configuration.filter;

import lombok.Data;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;
import pl.bucior.carrental.configuration.WsizException;
import pl.bucior.carrental.configuration.WsizExceptionEntity;

import java.io.Serializable;
import java.util.Date;

import static java.lang.String.format;
import static java.util.Optional.ofNullable;
import static org.springframework.http.HttpStatus.INTERNAL_SERVER_ERROR;

@ControllerAdvice
public class RestExceptionHandler extends ResponseEntityExceptionHandler {

    @ExceptionHandler({WsizException.class})
    protected ResponseEntity<WsizExceptionEntity> handleCoreException(WsizException e, WebRequest request) {
        String message = ofNullable(e.getMessage())
                .orElse(format("CoreException thrown: status %s, code %s, request %s", e.getErrorStatus().value(), e.getErrorCode(), request.getDescription(false)));
        logger.error(message, e);
        return ResponseEntity
                .status(e.getErrorStatus())
                .body(e.buildEntity());
    }

    @ExceptionHandler({Exception.class})
    protected ResponseEntity<ErrorDetails> handleAllExceptions(Exception e, WebRequest request) {
        String message = ofNullable(e.getMessage())
                .orElse(format("%s thrown: request %s", e.getClass().getSimpleName(), request.getDescription(false)));
        logger.error(message, e);
        return ResponseEntity
                .status(INTERNAL_SERVER_ERROR)
                .body(new ErrorDetails(new Date(), e.getMessage(), request.getDescription(false)));
    }

    @Data
    public static class ErrorDetails implements Serializable {
        private static final long serialVersionUID = 4024665201122170820L;
        protected final Date timestamp;
        protected final String message;
        protected final String details;
    }

}

