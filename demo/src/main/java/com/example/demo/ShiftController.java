package com.example.demo;

import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/shifts")
@CrossOrigin(origins = "*")
public class ShiftController {
    private final ShiftService shiftService;

    public ShiftController(ShiftService shiftService) {
        this.shiftService = shiftService;
    }

    @GetMapping
    public List<Shift> getShifts() {
        return shiftService.getAllShifts();
    }

    @GetMapping("/{id}")
    public Shift getShiftById(@PathVariable Integer id) {
        return shiftService.getShiftById(id);
    }

    @PostMapping
    public Shift addShift(@RequestBody Shift shift) {
        return shiftService.addShift(shift);
    }

    @PutMapping("/{id}")
    public Shift updateShift(@PathVariable Integer id, @RequestBody Shift shift) {
        return shiftService.updateShift(id, shift);
    }

    @DeleteMapping("/{id}")
    public void deleteShift(@PathVariable Integer id) {
        shiftService.deleteShift(id);
    }
}
