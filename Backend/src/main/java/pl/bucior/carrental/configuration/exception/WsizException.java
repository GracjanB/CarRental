package pl.bucior.carrental.configuration.exception;

import org.springframework.http.HttpStatus;

import java.util.ArrayList;
import java.util.List;

public class WsizException extends RuntimeException {
    private static final long serialVersionUID = 7973274436243945838L;
    private final HttpStatus errorStatus;
    private final ErrorCode errorCode;
    private final List<String> parameters;

    public WsizException(HttpStatus errorStatus) {
        this.errorStatus = errorStatus;
        this.errorCode = ErrorCode.NOT_ALLOWED;
        parameters = new ArrayList<>();
    }

    public WsizException(HttpStatus errorStatus, ErrorCode errorCode) {
        this.errorStatus = errorStatus;
        this.errorCode = errorCode;
        parameters = new ArrayList<>();
    }

    public WsizException(String message, HttpStatus errorStatus, ErrorCode errorCode) {
        super(message);
        this.errorStatus = errorStatus;
        this.errorCode = errorCode;
        parameters = new ArrayList<>();
    }

    public WsizException(String message, Throwable cause, HttpStatus errorStatus, ErrorCode errorCode) {
        super(message, cause);
        this.errorStatus = errorStatus;
        this.errorCode = errorCode;
        parameters = new ArrayList<>();
    }

    public WsizException(String message, HttpStatus errorStatus, ErrorCode errorCode, List<String> parameters) {
        super(message);
        this.errorStatus = errorStatus;
        this.errorCode = errorCode;
        this.parameters = new ArrayList<>(parameters);
    }

    public HttpStatus getErrorStatus() {
        return errorStatus;
    }

    public ErrorCode getErrorCode() {
        return errorCode;
    }

    public List<String> getParameters() {
        return parameters;
    }

    public WsizExceptionEntity buildEntity() {
        return WsizExceptionEntity.builder()
                .errorCode(errorCode)
                .parameters(parameters)
                .build();
    }

    @Override
    public String toString() {
        return "WsizException{" +
                "errorCode=" + errorStatus +
                ", errorSubcode=" + errorCode +
                '}';
    }
}
