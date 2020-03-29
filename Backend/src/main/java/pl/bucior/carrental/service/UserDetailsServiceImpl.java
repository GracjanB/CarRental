package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.repository.UserRepository;

@Service
@RequiredArgsConstructor
public class UserDetailsServiceImpl implements UserDetailsService {

    private final UserRepository userRepository;

    @Override
    public UserDetails loadUserByUsername(String s) throws UsernameNotFoundException {
        final User user = userRepository.findByEmail(s)
                .orElseThrow(() -> new UsernameNotFoundException(String.format("Email: %s not found", s)));

        SimpleGrantedAuthority authority = new SimpleGrantedAuthority("ROLE_" + user.getRole().name());
        return org.springframework.security.core.userdetails.User
                .builder()
                .authorities(authority)
                .username(s)
                .password(user.getPassword())
                .accountExpired(false)
                .accountLocked(false)
                .disabled(false)
                .build();
    }
}
