package com.bancolombia.app.services;

import java.util.List;

import com.bancolombia.app.entities.Client;

public interface IService {
	boolean insert(Client client);
	boolean deleteById(long id);
	boolean update(Client client);
	Client findById(long id);
	List<Client> getAll();
}
