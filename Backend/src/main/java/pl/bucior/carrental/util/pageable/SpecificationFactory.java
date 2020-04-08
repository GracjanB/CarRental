package pl.bucior.carrental.util.pageable;


import lombok.RequiredArgsConstructor;
import org.springframework.data.jpa.domain.Specification;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

@RequiredArgsConstructor
public class SpecificationFactory<T> {

    private final SpecificationsBuilder<T> builder;

    public Specification<T> createSpecification(String search) {//=,<>&
        Pattern pattern = Pattern.compile("(\\w+?)(=|<|>)([\\s\\w\\p{L}.\\-+:@!#$%^*(){}\\[\\]_'\"/\\\\|]+?),");
        Matcher matcher = pattern.matcher(search + ",");
        builder.clearParams();
        while (matcher.find()) {
            builder.with(matcher.group(1), matcher.group(2), matcher.group(3));
        }
        Specification<T> spec = builder.build();
        return spec;
    }

}