package com.juliospassky.restful.domain;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ICarroRepository extends JpaRepository<Carro, Long> {

    List<Carro> findByTipo(String tipo);
}
