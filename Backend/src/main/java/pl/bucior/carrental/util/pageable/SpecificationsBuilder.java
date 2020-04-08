package pl.bucior.carrental.util.pageable;

import org.springframework.data.jpa.domain.Specification;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class SpecificationsBuilder<T> {

    private final List<SearchCriteria> params;
    private final List<String> fields;


    public SpecificationsBuilder(List<String> fields) {
        this.params = new ArrayList<>();
        this.fields = fields;
    }

    public void clearParams() {
        params.clear();
    }

    public SpecificationsBuilder with(String key, String operation, Object value) {
        params.add(new SearchCriteria(key, operation, value));
        return this;
    }

    public Specification<T> build() {
        if (params.size() == 0) {
            return null;
        }

        List<Specification> specs = params.stream()
                .filter(p -> fields.contains(p.getKey()))
                .map(GenericSpecification<T>::new)
                .collect(Collectors.toList());

        if (specs.size() == 0) {
            return null;
        }

        Specification result = specs.get(0);

        for (int i = 1; i < params.size(); i++) {
            result = Specification.where(result).and(specs.get(i));
        }
        params.clear();
        return result;
    }

}