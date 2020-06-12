package pl.bucior.carrental.util.pageable;


import lombok.Builder;
import lombok.Value;

import java.io.Serializable;

@Value
@Builder
public class ObjectResponse implements Serializable {

    private static final long serialVersionUID = 7701208187271660774L;

    private int statusCode;
    private String message;
    private Object data;

}
