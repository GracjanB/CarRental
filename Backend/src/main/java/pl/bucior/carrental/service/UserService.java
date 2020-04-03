package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.http.HttpStatus;
import org.springframework.security.crypto.bcrypt.BCrypt;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.enums.Role;
import pl.bucior.carrental.model.jpa.AccountVerificationToken;
import pl.bucior.carrental.model.jpa.Address;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.request.UserCreateRequest;
import pl.bucior.carrental.model.response.UserRoleResponse;
import pl.bucior.carrental.repository.AccountVerificationTokenRepository;
import pl.bucior.carrental.repository.AddressRepository;
import pl.bucior.carrental.repository.UserRepository;
import pl.bucior.carrental.service.event.OnRegistrationCompleteEvent;

import javax.transaction.Transactional;
import java.security.Principal;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class UserService {

    private final UserRepository userRepository;
    private final AccountVerificationTokenRepository accountVerificationTokenRepository;
    private final ApplicationEventPublisher applicationEventPublisher;


    public void create(UserCreateRequest request) {

        String salt = BCrypt.gensalt();
        String encryptedPassword = BCrypt.hashpw(request.getPassword(), salt);

        if (userRepository.findByEmail(request.getEmail()).isPresent()) {
            throw new WsizException(String.format("User with email: %s exists.", request.getEmail()), HttpStatus.CONFLICT, ErrorCode.EMAIL_ALREADY_EXISTS);
        }
        User user = userRepository.save(User.builder()
                .email(request.getEmail())
                .password(encryptedPassword)
                .role(Role.MANAGER)
                .salt(salt)
                .address(Address.builder()
                        .city(request.getCity())
                        .country(request.getCountry())
                        .flatNo(request.getFlatNo())
                        .houseNo(request.getHouseNo())
                        .postalCode(request.getPostalCode())
                        .street(request.getStreet())
                        .build())
                .firstName(request.getFirstName())
                .lastName(request.getLastName())
                .idCardNumber(request.getIdCardNumber())
                .pesel(request.getPesel())
                .isActive(false)
                .build());
        if (user.getId() != null) {
            try {
                applicationEventPublisher.publishEvent(new OnRegistrationCompleteEvent(user));
            } catch (Exception e) {
                log.error("Error while try to publish registration event for userId = " + user.getId());
            }
        }
    }

    public void confirmRegistration(String token) {
        AccountVerificationToken accountVerificationToken = accountVerificationTokenRepository.findByToken(token)
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND));
        accountVerificationToken.getUser().setIsActive(true);
    }

    public UserRoleResponse checkRole(Principal principal) {
        UserRoleResponse response = new UserRoleResponse();
        response.setRole(userRepository.findByEmail(principal.getName()).orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND)).getRole());
        return response;
    }


}