package pl.bucior.carrental.service;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.repository.AccountVerificationTokenRepository;
import pl.bucior.carrental.repository.UserRepository;

import java.util.UUID;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;
import static org.mockito.MockitoAnnotations.initMocks;

class AccountVerificationTokenServiceTest {


    @InjectMocks
    private AccountVerificationTokenService accountVerificationTokenService;

    @Mock
    private AccountVerificationTokenRepository accountVerificationTokenRepository;
    @Mock
    private UserRepository userRepository;

    @BeforeEach
    void setUp() {
        initMocks(this);
    }

    @Test
    void createVerificationToken() {
        String token = UUID.randomUUID().toString();
        Long userId = 1L;
        when(userRepository.findById(userId))
                .thenReturn(java.util.Optional.ofNullable(User.builder()
                        .id(1L)
                        .firstName("Paweł")
                        .lastName("Abrakadabra")
                        .build()));
        accountVerificationTokenService.createVerificationToken(1L, token);
        verify(accountVerificationTokenRepository, times(1)).save(
                any());

    }

    @Test
    void changeStatus() {
        String token = UUID.randomUUID().toString();
        accountVerificationTokenService.changeStatus(token);
        verify(accountVerificationTokenRepository,times(1))
                .findByToken(token);


    }
}