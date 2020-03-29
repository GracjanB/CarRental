package pl.bucior.carrental.configuration;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;
import lombok.experimental.SuperBuilder;

import java.io.Serializable;
import java.util.List;

@Getter
@Setter
@ToString
@NoArgsConstructor
@SuperBuilder
public class WsizExceptionEntity implements Serializable {

    private static final long serialVersionUID = -5955164475273553932L;
    private ErrorCode errorCode;
    private List<String> parameters;

}
