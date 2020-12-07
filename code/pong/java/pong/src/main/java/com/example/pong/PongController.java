package com.example.pong;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.Objects;

@RestController
public class PongController {


    @PostMapping("/pong")
    public String index(@RequestBody String s) {

        return Objects.isNull(s) ? null : s;
    }

}