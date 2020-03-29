package pl.bucior.carrental.resource;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class QueryResource{

    @GetMapping("/")
    String sayHello(){
        return "Hello world!";
    }

}
