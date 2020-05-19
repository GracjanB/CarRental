package pl.bucior.carrental.service.event;

import lombok.Getter;
import lombok.Setter;
import org.springframework.context.ApplicationEvent;

@Getter
@Setter
public class OnRegistrationCompleteEvent extends ApplicationEvent {

    public OnRegistrationCompleteEvent(Object source) {
        super(source);
    }
}
