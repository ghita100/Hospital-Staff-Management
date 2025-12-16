package com.example.demo;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/doctors")
@CrossOrigin(origins = "*")
public class DoctorController {
    private DoctorService doctorService;

    public DoctorController(DoctorService doctorService){
        this.doctorService=doctorService;
    }
    @GetMapping
    public List<Doctor> getDoctors(){
        return doctorService.getallDoctors();
    }
    @GetMapping("/{id}")
    public Doctor getDoctorById(@PathVariable Integer id) {
        return doctorService.getDoctorById(id);
    }

    @PostMapping
    public Doctor addDoctor(@RequestBody Doctor doctor){
        return doctorService.addDoctor(doctor);
    }
    @PutMapping("/{id}")
    public Doctor updateDoctor(@PathVariable Integer id, @RequestBody Doctor doctor) {
        return doctorService.updateDoctor(id, doctor);
    }
    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteDoctor(@PathVariable Integer id) {

        try {
            doctorService.deleteDoctor(id);
            return ResponseEntity.ok("Sters cu succes");
        } catch (Exception e) {
            System.err.println("--- [EROARE] " + e.getMessage());
            e.printStackTrace();
            return ResponseEntity.status(500).body(e.getMessage());
        }
    }

    @GetMapping("/department/{departmentId}")
    public List<Doctor> getDoctorsByDepartment(@PathVariable Integer departmentId) {
        return doctorService.getDoctorsByDepartment(departmentId);
    }

    @GetMapping("/specialization/{specialization}")
    public List<Doctor> getDoctorsBySpecialization(@PathVariable String specialization) {
        return doctorService.getDoctorsBySpecialization(specialization);
    }


    @GetMapping("/busy")
    public List<Doctor> getBusyDoctors() {
        return doctorService.getBusyDoctors();
    }



}
