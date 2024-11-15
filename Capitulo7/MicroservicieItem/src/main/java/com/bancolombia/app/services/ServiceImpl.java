package com.bancolombia.app.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.bancolombia.app.datasource.ItemRepository;
import com.bancolombia.app.entities.Item;

@Service
public class ServiceImpl implements IService{
	
	@Autowired
	private ItemRepository repository;

	@Override
	public boolean insert(Item item) {
		
		return repository.insert(item);
	}

	@Override
	public boolean deleteById(long id) {
		
		return repository.deleteById(id);
	}

	@Override
	public boolean update(Item item) {
		
		return repository.update(item);
	}

	@Override
	public List<Item> getAll() {
		
		return repository.getAll();
	}
	
	

}
