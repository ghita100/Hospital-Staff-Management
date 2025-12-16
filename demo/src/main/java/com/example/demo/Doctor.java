package com.example.demo;

import com.fasterxml.jackson.annotation.*;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Data;

import java.util.List;

@Entity
@Data
@AllArgsConstructor
@NoArgsConstructor
@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
public class Doctor {
    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    private Integer id;

    private String name;
    private String specialization;


    @ManyToOne
    @JoinColumn(name="department_id", nullable=true)
    @JsonBackReference
    private Department department;

    @OneToMany(mappedBy = "doctor", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
    @JsonManagedReference
    private List<Shift> shifts;

    @Override
    public String toString() {
        return "{"
                + "\"id\": " + id + ", "
                + "\"name\": \"" + name + "\", "
                + "\"specialization\": \"" + specialization + "\""
                + "}";
    }

}
