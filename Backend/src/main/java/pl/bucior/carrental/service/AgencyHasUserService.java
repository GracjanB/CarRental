package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.enums.Role;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.jpa.AgencyHasUser;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.request.HireEmployeeRequest;
import pl.bucior.carrental.repository.AgencyHasUserRepository;
import pl.bucior.carrental.repository.AgencyRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;
import java.time.ZonedDateTime;
import java.time.chrono.ChronoZonedDateTime;

import static pl.bucior.carrental.configuration.exception.ErrorCode.*;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class AgencyHasUserService {

    private final AgencyHasUserRepository agencyHasUserRepository;
    private final AgencyRepository agencyRepository;
    private final UserRepository userRepository;

    public void hireEmployee(HireEmployeeRequest request) {
        if (agencyHasUserRepository.findByUserId(request.getUserId()).isPresent()) {
            throw new WsizException(HttpStatus.CONFLICT, USER_IS_ALREADY_EMPLOYED);
        }
        if (request.getRole().equals(Role.MANAGER) || request.getRole().equals(Role.USER)) {
            throw new WsizException(HttpStatus.CONFLICT, INVAILD_ROLE);
        }
        validateDates(request.getStartContractTime(), request.getEndContractTime());
        Agency agency = agencyRepository.findById(request.getAgencyId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.AGENCY_NOT_FOUND));
        User employee = userRepository.findById(request.getUserId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND));
        agencyHasUserRepository.save(AgencyHasUser
                .builder()
                .agency(agency)
                .user(employee)
                .endContractTime(request.getEndContractTime())
                .startContractTime(request.getStartContractTime())
                .build());
        employee.setRole(request.getRole());
    }

    public void fireEmployee(Long userId) {
        AgencyHasUser agencyHasUser = agencyHasUserRepository.findByUserId(userId)
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, AGENCY_HAS_USER_NOT_FOUND));
        agencyHasUser.setEndContractTime(ZonedDateTime.now());
        agencyHasUser.getUser().setRole(Role.USER);
    }

    void validateDates(ZonedDateTime startDate, ZonedDateTime endDate) {
        if (startDate.isBefore(ChronoZonedDateTime.from(ZonedDateTime.now())) ||
                startDate.isAfter(ChronoZonedDateTime.from(endDate))) {
            throw new WsizException(HttpStatus.CONFLICT, ErrorCode.INVAILD_START_OR_END_CONTRACT_DATE);
        }
    }

}
