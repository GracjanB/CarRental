package pl.bucior.carrental.util.pageable;

import org.springframework.data.jpa.domain.Specification;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.time.ZonedDateTime;

public class GenericSpecification<T> implements Specification<T> {

    private SearchCriteria criteria;

    public GenericSpecification(SearchCriteria criteria) {
        super();
        this.criteria = criteria;
    }

    @Override
    public Predicate toPredicate
            (Root<T> root, CriteriaQuery<?> query, CriteriaBuilder builder) {

        if (criteria.getOperation().equalsIgnoreCase("=")) {
            if (root.get(criteria.getKey()).getJavaType().isEnum()) {
                return builder.equal(root.get(criteria.getKey()).as(String.class), criteria.getValue());
            } else if (root.get(criteria.getKey()).getJavaType() == BigDecimal.class
                    || root.get(criteria.getKey()).getJavaType() == BigInteger.class
                    || root.get(criteria.getKey()).getJavaType() == Long.class
                    || root.get(criteria.getKey()).getJavaType() == Integer.class) {
                return builder.equal((root.get(criteria.getKey())), criteria.getValue());
            } else if (root.get(criteria.getKey()).getJavaType() == ZonedDateTime.class) {
                return builder.like(root.get(criteria.getKey()).as(String.class), "%" + criteria.getValue() + "%");
            } else {
                return builder.like(builder.lower(root.get(criteria.getKey()).as(String.class)), "%" + ((String) criteria.getValue()).toLowerCase() + "%");
            }
        } else if (criteria.getOperation().equalsIgnoreCase(">")) {
            return builder.greaterThanOrEqualTo(
                    root.<String>get(criteria.getKey()), criteria.getValue().toString());
        } else if (criteria.getOperation().equalsIgnoreCase("<")) {
            return builder.lessThanOrEqualTo(
                    root.<String>get(criteria.getKey()), criteria.getValue().toString());
        }
        return null;
    }


}