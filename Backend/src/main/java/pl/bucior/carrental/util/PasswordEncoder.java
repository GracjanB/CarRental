package pl.bucior.carrental.util;

import org.springframework.stereotype.Service;

@Service
public class PasswordEncoder implements org.springframework.security.crypto.password.PasswordEncoder {

    public String encode(CharSequence rawPassword) {
        return rawPassword.toString();
    }

    public boolean matches(CharSequence rawPassword, String encodedPassword) {
        return rawPassword.toString().equals(encodedPassword);
    }
}
