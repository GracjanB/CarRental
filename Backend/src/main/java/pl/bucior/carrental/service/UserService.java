package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.security.crypto.bcrypt.BCrypt;
import org.springframework.security.oauth2.provider.token.DefaultTokenServices;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.ErrorCode;
import pl.bucior.carrental.configuration.WsizException;
import pl.bucior.carrental.model.enums.Role;
import pl.bucior.carrental.model.jpa.Address;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.request.UserCreateRequest;
import pl.bucior.carrental.model.response.UserRoleResponse;
import pl.bucior.carrental.repository.AddressRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;
import java.security.Principal;

@Service
@Transactional
@RequiredArgsConstructor
public class UserService {

    private final UserRepository userRepository;
    private final AddressRepository addressRepository;

    public void create(UserCreateRequest request) {

        String salt = BCrypt.gensalt();
        String encryptedPassword = BCrypt.hashpw(request.getPassword(), salt);

        if (userRepository.findByEmail(request.getEmail()).isPresent()) {
            throw new WsizException(String.format("User with email: %s exists.", request.getEmail()), HttpStatus.CONFLICT, ErrorCode.EMAIL_ALREADY_EXISTS);
        }
        Address address = addressRepository.save(Address.builder()
                .city(request.getCity())
                .country(request.getCountry())
                .flatNo(request.getFlatNo())
                .houseNo(request.getHouseNo())
                .postalCode(request.getPostalCode())
                .street(request.getStreet())
                .build());

        User user = User.builder()
                .email(request.getEmail())
                .password(encryptedPassword)
                .role(Role.MANAGER)
                .salt(salt)
                .address(address)
                .firstName(request.getFirstName())
                .lastName(request.getLastName())
                .idCardNumber(request.getIdCardNumber())
                .pesel(request.getPesel())
                .build();
        userRepository.save(user);
    }



//    public User findByLogin(String login){
//        return userRepository.findByLogin(login);
//    }
//    /**
//     * <p>
//     *     Metoda wylogowująca użytkownika z systemu
//     * </p>
//     * @param request Są to szczegóły requesta który dochodzi do systemmu
//     * @return True jeśli wylogowano
//     */
//    public boolean deleteToken(HttpServletRequest request) {
//        String authorization = request.getHeader(HttpHeaders.AUTHORIZATION);
//        authorization = authorization.replaceAll("Bearer ", "");
//        return defaultTokenServices.revokeToken(authorization);
//    }
//
public UserRoleResponse checkRole(Principal principal) {
    UserRoleResponse response = new UserRoleResponse();
    response.setRole(userRepository.findByEmail(principal.getName()).orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND)).getRole());
    return response;
}


}