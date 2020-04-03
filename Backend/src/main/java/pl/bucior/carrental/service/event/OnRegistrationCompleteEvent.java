package pl.bucior.carrental.service.event;

import lombok.Getter;
import lombok.Setter;
import org.springframework.context.ApplicationEvent;

import java.util.Locale;

@Getter
@Setter
public class OnRegistrationCompleteEvent extends ApplicationEvent {

    private final Locale locale = Locale.getDefault();

    public OnRegistrationCompleteEvent(Object source) {
        super(source);
    }
}
