package com.bancolombia.app.services;

import java.util.List;

import com.bancolombia.app.entities.Item;

public interface IService {
	public boolean insert(Item item);
	public boolean deleteById(long id);
	public boolean update(Item item);
	public List<Item> getAll();
}
