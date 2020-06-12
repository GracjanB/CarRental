package pl.bucior.carrental.configuration;

import lombok.RequiredArgsConstructor;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import pl.bucior.carrental.repository.AgencyHasUserRepository;
import pl.bucior.carrental.repository.UserRepository;
import pl.bucior.carrental.service.AuthorizationInterceptor;

@Configuration
@RequiredArgsConstructor
public class AuthConfiguration implements WebMvcConfigurer {

    private final AgencyHasUserRepository agencyHasUserRepository;
    private final UserRepository userRepository;


    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        registry.addInterceptor(new AuthorizationInterceptor(agencyHasUserRepository, userRepository));
    }


}
