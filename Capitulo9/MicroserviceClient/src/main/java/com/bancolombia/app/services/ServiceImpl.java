package com.bancolombia.app.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.bancolombia.app.dao.IClientDAO;
import com.bancolombia.app.entities.Client;

@Service
public class ServiceImpl implements IService {
	
	@Autowired
	private IClientDAO dao;

	@Override
	public boolean insert(Client client) {
		if(dao.save(client)!=null) {
		   return true;
		}
		
		return false;
	}

	@Override
	public boolean deleteById(long id) {
		if(dao.existsById(id)) {
		    dao.deleteById(id);
		    return true;
			
		}
		
		return false;
	}

	@Override
	public boolean update(Client client) {
	    if(dao.existsById(client.getId())) {
	    	dao.save(client);
	    	return true;
	    }
		
		return false;
	}

	@Override
	public Client findById(long id) {
		return dao.findById(id)
				.orElseThrow();
	}

	@Override
	public List<Client> getAll() {
		return (List<Client>)dao.findAll();
	}

}
