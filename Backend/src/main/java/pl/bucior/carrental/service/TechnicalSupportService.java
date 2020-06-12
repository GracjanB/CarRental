package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.mapper.TechnicalSupportMapper;
import pl.bucior.carrental.model.dto.TechnicalSupportDto;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.response.TechnicalSupportResponse;
import pl.bucior.carrental.repository.AgencyHasUserRepository;
import pl.bucior.carrental.repository.TechnicalSupportRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;
import java.security.Principal;
import java.util.List;
import java.util.stream.Collectors;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class TechnicalSupportService {

    private final TechnicalSupportRepository technicalSupportRepository;
    private final AgencyHasUserRepository agencyHasUserRepository;
    private final UserRepository userRepository;

    public TechnicalSupportResponse getAllFreeTechnicalSupport(Principal principal) {
        User employee = userRepository.findByEmail(principal.getName())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND));
        Agency agency = agencyHasUserRepository.findByUserId(employee.getId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.AGENCY_HAS_USER_NOT_FOUND)).getAgency();
        List<TechnicalSupportDto> technicalSupports = technicalSupportRepository
                .findAllByStatusAndAgency(agency.getId()).stream()
                .map(TechnicalSupportMapper.INSTANCE::toDto).collect(Collectors.toList());
        TechnicalSupportResponse technicalSupportResponse = new TechnicalSupportResponse();
        technicalSupportResponse.setTechnicalSupports(technicalSupports);
        return technicalSupportResponse;
   }


}
