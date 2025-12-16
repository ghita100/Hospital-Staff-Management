package com.example.demo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

@Repository
public interface DoctorRepository extends JpaRepository<Doctor,Integer> {
    @Query("SELECT d FROM Doctor d WHERE d.department.id = :departmentId")
    List<Doctor> findDoctorsByDepartmentId(@Param("departmentId") Integer departmentId);

    @Query("SELECT d FROM Doctor d WHERE LOWER(d.specialization) = LOWER(:specialization)")
    List<Doctor> findDoctorsBySpecialization(@Param("specialization") String specialization);
}
