package pl.bucior.carrental.resource;


import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.configuration.auth.TechnicalEmployee;
import pl.bucior.carrental.model.response.TechnicalSupportResponse;
import pl.bucior.carrental.service.TechnicalSupportService;

import javax.servlet.http.HttpServletRequest;
import java.security.Principal;

@RestController
@RequestMapping("technicalSupport")
@RequiredArgsConstructor
public class TechnicalSupportResource {

    private final TechnicalSupportService technicalSupportService;

    @GetMapping("/free")
//    @TechnicalEmployee
    public ResponseEntity<TechnicalSupportResponse> getAllFreeTechnicalSupport(Principal principal) {
        return ResponseEntity.ok(technicalSupportService.getAllFreeTechnicalSupport(principal));
    }

}
