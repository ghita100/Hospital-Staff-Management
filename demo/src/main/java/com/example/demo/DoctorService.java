package com.example.demo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;
import org.springframework.transaction.annotation.Transactional;
@Service

public class DoctorService {

    private DoctorRepository doctorRepository;
    @Autowired
    public DoctorService(DoctorRepository doctorRepository){
        this.doctorRepository=doctorRepository;
    }
    public Doctor addDoctor(Doctor doctor){
        return doctorRepository.save(doctor);
    }
    public List<Doctor> getallDoctors(){
        return doctorRepository.findAll();
    }

    public Doctor updateDoctor(Integer id, Doctor doctor) {
        Doctor existingDoctor = doctorRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Doctor not found with id: " + id));

        existingDoctor.setName(doctor.getName());
        existingDoctor.setSpecialization(doctor.getSpecialization());

        return doctorRepository.save(existingDoctor);
    }
    public Doctor getDoctorById(Integer id) {
        return doctorRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Doctor not found with id: " + id));
    }

    @Transactional
    public void deleteDoctor(Integer id) {
        Doctor doctor = doctorRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Doctorul cu ID " + id + " nu a fost gasit!"));


        if (doctor.getDepartment() != null) {
            doctor.setDepartment(null);
            doctorRepository.saveAndFlush(doctor);
        }

        doctorRepository.delete(doctor);

        doctorRepository.flush();

    }

    public List<Doctor> getDoctorsByDepartment(Integer departmentId) {
        return doctorRepository.findDoctorsByDepartmentId(departmentId);
    }

    public List<Doctor> getDoctorsBySpecialization(String specialization) {
        return doctorRepository.findDoctorsBySpecialization(specialization);
    }

    public List<Doctor> getBusyDoctors() {
        return doctorRepository.findAll().stream()
                .filter(d -> d.getShifts() != null && !d.getShifts().isEmpty())
                .toList();
    }

}
