package pl.bucior.carrental.service.event;

import lombok.Getter;
import lombok.Setter;
import org.springframework.context.ApplicationEvent;

@Getter
@Setter
public class EmailEvent extends ApplicationEvent {

    public EmailEvent(Object source) {
        super(source);
    }
}
