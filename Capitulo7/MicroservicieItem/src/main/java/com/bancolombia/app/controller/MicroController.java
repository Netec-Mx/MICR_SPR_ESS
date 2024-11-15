package com.bancolombia.app.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.bancolombia.app.entities.Item;
import com.bancolombia.app.services.IService;

@RestController
@RequestMapping("/item")
public class MicroController {
	@Autowired
	private IService service;
	
	@PostMapping
	public ResponseEntity<Boolean> insert(@RequestBody Item item){
		
		if(service.insert(item)) {
			return new ResponseEntity<Boolean>(true, HttpStatus.CREATED);
		}
		return new ResponseEntity<Boolean>(false, HttpStatus.BAD_REQUEST);
	} 
	
	
	
	@GetMapping
	public ResponseEntity<List<Item>> getAll(){
		
		return new ResponseEntity<List<Item>>(service.getAll(), HttpStatus.OK);
	}
	
	
	@DeleteMapping
	public ResponseEntity<Boolean> delete(@RequestParam("id") long id){
	     if(service.deleteById(id)) {
	    	 return new ResponseEntity<Boolean>(true, HttpStatus.OK);
	     }
	     return new ResponseEntity<Boolean>(false, HttpStatus.NOT_FOUND);
	}
	
	@PutMapping
	public ResponseEntity<Boolean> update(@RequestBody Item item){
		if(service.update(item)) {
			return new ResponseEntity<Boolean>(true, HttpStatus.OK);
		}
		return new ResponseEntity<Boolean>(false, HttpStatus.NOT_FOUND);
		
	}
	
	
	

}
