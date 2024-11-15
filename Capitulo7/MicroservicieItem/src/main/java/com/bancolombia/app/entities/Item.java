package com.bancolombia.app.entities;

public class Item {
	private long id;
	private String name;
	private String brand;
	private double amount;
	private String description;
	
	
	public Item(String name, String brand, double amount, String description) {
		super();
		this.name = name;
		this.brand = brand;
		this.amount = amount;
		this.description = description;
	}
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getBrand() {
		return brand;
	}
	public void setBrand(String brand) {
		this.brand = brand;
	}
	public double getAmount() {
		return amount;
	}
	public void setAmount(double amount) {
		this.amount = amount;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	

}
