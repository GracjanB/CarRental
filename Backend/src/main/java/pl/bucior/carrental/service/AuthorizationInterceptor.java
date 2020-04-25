package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.servlet.handler.HandlerInterceptorAdapter;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.enums.Role;
import pl.bucior.carrental.repository.AgencyHasUserRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.time.ZonedDateTime;

import static pl.bucior.carrental.configuration.exception.ErrorCode.CONTRACT_EXPIRED;

@Service
@RequiredArgsConstructor
public class AuthorizationInterceptor extends HandlerInterceptorAdapter {

    private final AgencyHasUserRepository agencyHasUserRepository;
    private final UserRepository userRepository;

    @Override
    public boolean preHandle(HttpServletRequest request, HttpServletResponse response, Object handler) throws Exception {
        if (request.isUserInRole(Role.EMPLOYEE.name()) || request.isUserInRole(Role.TECHNICAL_EMPLOYEE.name())) {
            if (agencyHasUserRepository.findByUserId(userRepository.findByEmail(request.getUserPrincipal().getName())
                    .orElseThrow(AssertionError::new).getId()).orElseThrow(AssertionError::new).getEndContractTime().isBefore(ZonedDateTime.now())) {
                throw new WsizException(HttpStatus.UNAUTHORIZED, CONTRACT_EXPIRED);
            }
        }
        return super.preHandle(request, response, handler);
    }
}
