package com.juliospassky.restful.domain;

import com.juliospassky.restful.domain.dto.CarroDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.Assert;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class CarroService {

    @Autowired
    private ICarroRepository _rep;

    public List<CarroDTO> getCarros() {
        return _rep.findAll().stream().map(CarroDTO::create).collect(Collectors.toList());
    }

    public Optional<CarroDTO> getCarrosDTOById(Long id) {
        return _rep.findById(id).map(CarroDTO::create);
    }

    public Optional<Carro> getCarrosById(Long id) {
        return _rep.findById(id);
    }

    public List<CarroDTO> getCarrosByTipo(String tipo) {
        return _rep.findByTipo(tipo).stream().map(CarroDTO::create).collect(Collectors.toList());
    }

    public CarroDTO insert(Carro carro) {
        Assert.isNull(carro.getId(), "Bad Request");
        return CarroDTO.create(_rep.save(carro));
    }

    public CarroDTO update(Long id, Carro carro) {
        Assert.notNull(id, "Id não informado");
        Optional<Carro> optional = getCarrosById(id);

        if (optional.isPresent()) {
            Carro db = optional.get();
            db.updateCarro(carro);

            _rep.save(db);

            return CarroDTO.create(db);
        } else {
            return null;
        }
    }

    public boolean delete(Long id) {
        if (getCarrosById(id).isPresent()) {
            _rep.deleteById(id);
            return true;
        } else
            return false;
    }
}
