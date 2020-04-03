package pl.bucior.carrental.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.support.ResourceBundleMessageSource;

@Configuration
public class MessageConfig {
    @Bean
    public ResourceBundleMessageSource messageSource() {

        var source = new ResourceBundleMessageSource();
        source.setBasenames("messages/message");
        source.setUseCodeAsDefaultMessage(true);

        return source;
    }

}
