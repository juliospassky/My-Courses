package com.juliospassky.restful.api;

import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/")
public class IndexController {

    @GetMapping
    public String get() {
        return "Get World!";
    }

    @PostMapping
    public String post() {
        return "Post World!";
    }

    @PutMapping
    public String put() {
        return "Put World!";
    }

    @DeleteMapping
    public String delete() {
        return "Delete World!";
    }
}
