package com.juliospassky.restful.domain;

import lombok.Data;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
@Data
public class Carro {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String nome;
    private String tipo;

    public void updateCarro(Carro carro) {
        this.nome = carro.getNome();
        this.tipo = carro.getTipo();
    }
}
