'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { createProduct } from '@/redux/slices/productSlice';
import { fetchCategories } from '@/redux/slices/categorySlice';
import Link from 'next/link';

export default function NewProductPage() {
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();
  const { loading, error } = useSelector((state: RootState) => state.products);
  const { categories } = useSelector((state: RootState) => state.categories);
  
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState('');
  const [categoryId, setCategoryId] = useState('');
  const [image, setImage] = useState<File | null>(null);
  const [imagePreview, setImagePreview] = useState<string | null>(null);
  
  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);
  
  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      setImage(file);
      
      // Create preview
      const reader = new FileReader();
      reader.onload = (e) => {
        setImagePreview(e.target?.result as string);
      };
      reader.readAsDataURL(file);
    }
  };
  
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    const formData = new FormData();
    formData.append('name', name);
    formData.append('description', description);
    formData.append('price', price);
    formData.append('categoryId', categoryId);
    if (image) {
      formData.append('image', image);
    }
    
    const result = await dispatch(createProduct(formData));
    if (result.meta.requestStatus === 'fulfilled') {
      router.push('/dashboard/products');
    }
  };
  
  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Yeni Ürün Ekle</h1>
        <Link href="/dashboard/products" className="btn btn-secondary">
          Geri Dön
        </Link>
      </div>
      
      <div className="card">
        {error && (
          <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded mb-4">
            {error}
          </div>
        )}
        
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2">
              <label htmlFor="name" className="block font-medium">Ürün Adı</label>
              <input
                id="name"
                type="text"
                className="input"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
              />
            </div>
            
            <div className="space-y-2">
              <label htmlFor="price" className="block font-medium">Fiyat (TL)</label>
              <input
                id="price"
                type="number"
                step="0.01"
                min="0"
                className="input"
                value={price}
                onChange={(e) => setPrice(e.target.value)}
                required
              />
            </div>
            
            <div className="space-y-2">
              <label htmlFor="category" className="block font-medium">Kategori</label>
              <select
                id="category"
                className="input"
                value={categoryId}
                onChange={(e) => setCategoryId(e.target.value)}
                required
              >
                <option value="">Kategori Seçin</option>
                {categories.map((category) => (
                  <option key={category.id} value={category.id}>
                    {category.name}
                  </option>
                ))}
              </select>
            </div>
            
            <div className="space-y-2">
              <label htmlFor="image" className="block font-medium">Ürün Görseli</label>
              <input
                id="image"
                type="file"
                accept="image/*"
                className="input py-1"
                onChange={handleImageChange}
              />
            </div>
          </div>
          
          <div className="space-y-2">
            <label htmlFor="description" className="block font-medium">Açıklama</label>
            <textarea
              id="description"
              rows={4}
              className="input"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              required
            ></textarea>
          </div>
          
          {imagePreview && (
            <div>
              <p className="font-medium mb-2">Görsel Önizleme</p>
              <img 
                src={imagePreview} 
                alt="Preview" 
                className="max-h-48 border rounded"
              />
            </div>
          )}
          
          <div className="pt-4">
            <button 
              type="submit" 
              className="btn btn-primary w-full md:w-auto"
              disabled={loading}
            >
              {loading ? 'Kaydediliyor...' : 'Ürünü Kaydet'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}