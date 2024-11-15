package com.bancolombia.app.datasource;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.stereotype.Component;

import com.bancolombia.app.entities.Item;
import com.bancolombia.app.utils.ResponseUtil;

@Component
public class ItemRepository {
	private List<Item> items= new ArrayList<>();
	
	public ItemRepository() {
		insert(new Item("agua", "epura", 25,"agua de manantial"));
		insert(new Item("leche", "alpura", 29,"deslactosada"));
		insert(new Item("jabón rey", "rey", 1,"jabón multiusos"));
	}
	
	public boolean insert(Item item) {
	    final ResponseUtil response=new ResponseUtil();
	    response.setResponseBoolean(false);
	    
	    try {
	    Optional.of(items.get(items.size()-1))
	    .ifPresent(t->{
	    	item.setId(t.getId()+1);
	    	response.setResponseBoolean(items.add(item));
	    });
	   
	    }catch(IndexOutOfBoundsException ex ) {
	    	item.setId(0);
	    	response.setResponseBoolean(items.add(item));
	    }
	   
	    return response.getResponseBoolean();
		
	}
	
	public boolean deleteById(long id) {
		
		Optional<Item> search=items.stream()
				.filter(t->t.getId()==id)
				.findFirst();
		
		if(search.isPresent()) {
			items.remove(search.get());
			return true;
		}
		
		return false;
	}
	
	public boolean update(Item item) {
		Optional<Item> search=items
				.stream()
				.filter(t->t.getId()==item.getId())
				.findFirst();
		if(search.isPresent()) {
			search.get().setName(item.getName());
			search.get().setBrand(item.getBrand());
			search.get().setAmount(item.getAmount());
			search.get().setDescription(item.getDescription());
		    return true;
		}
		
		return false;
	}
	
	public List<Item> getAll(){
		return items;
	}

}
