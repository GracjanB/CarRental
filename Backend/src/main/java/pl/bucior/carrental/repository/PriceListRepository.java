package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.PriceList;
import pl.bucior.carrental.model.jpa.PriceList_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Repository
public interface PriceListRepository extends PageableJpaRepository<PriceList, Long> {

    @Override
    default String getKeyName() {
        return PriceList_.ID;
    }


}
