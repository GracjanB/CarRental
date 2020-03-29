package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.security.crypto.bcrypt.BCrypt;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.oauth2.provider.token.DefaultTokenServices;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.Role;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.request.UserCreateRequest;
import pl.bucior.carrental.repository.UserRepository;
import pl.bucior.carrental.util.PasswordHashUtil;

import javax.xml.bind.DatatypeConverter;
import java.nio.charset.StandardCharsets;
import java.util.Arrays;

@Service
@RequiredArgsConstructor
public class UserService {

    private final UserRepository userRepository;
    private final DefaultTokenServices defaultTokenServices;

    public void create(UserCreateRequest request) {

        String salt = BCrypt.gensalt();
        String encryptedPassword = BCrypt.hashpw(request.getPassword(), salt);

        if (userRepository.findByEmail(request.getEmail()).isPresent()) {
            throw new IllegalArgumentException("These email is busy");
        }

        User user = User.builder()
                .email(request.getEmail())
                .password(encryptedPassword)
                .role(Role.MANAGER)
                .salt(salt)
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
//    /**
//     * <p>
//     *     Metoda sprawdzająca czy użytkownik jest adminem
//     * </p>
//     * @param principal Informacje o użytkowniku wywołującym metode
//     * @return True jesli jest adminem
//     */
//    public boolean isAdmin(Principal principal){
//        if(userRepository.findByLogin(principal.getName()).getRole()== User.Role.A)
//        return true;
//        else
//            return false;
//    }


}