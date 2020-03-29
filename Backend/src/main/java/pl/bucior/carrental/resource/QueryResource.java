package pl.bucior.carrental.resource;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.configuration.auth.Manager;
import pl.bucior.carrental.configuration.auth.User;

@RestController
public class QueryResource {

    @Manager
    @User
    @GetMapping("/")
    String sayHello() {
        return "Hello world!";
    }

}
