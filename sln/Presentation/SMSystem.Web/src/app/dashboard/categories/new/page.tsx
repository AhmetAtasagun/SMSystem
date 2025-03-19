'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { createCategory } from '@/redux/slices/categorySlice';
import { fetchCategories } from '@/redux/slices/categorySlice';
import Link from 'next/link';

export default function NewCategoryPage() {
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();
  const { loading, error, categories } = useSelector((state: RootState) => state.categories);
  
  const [name, setName] = useState('');
  const [parentId, setParentId] = useState<string>('');
  
  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);
  
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    const categoryData = {
      name,
      parentId: parentId ? parseInt(parentId) : null,
    };
    
    const result = await dispatch(createCategory(categoryData));
    if (result.meta.requestStatus === 'fulfilled') {
      router.push('/dashboard/categories');
    }
  };
  
  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Yeni Kategori Ekle</h1>
        <Link href="/dashboard/categories" className="btn btn-secondary">
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
          <div className="space-y-2">
            <label htmlFor="name" className="block font-medium">Kategori Adı</label>
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
            <label htmlFor="parentId" className="block font-medium">Üst Kategori (Opsiyonel)</label>
            <select
              id="parentId"
              className="input"
              value={parentId}
              onChange={(e) => setParentId(e.target.value)}
            >
              <option value="">Üst Kategori Seçin (Opsiyonel)</option>
              {categories.map((category) => (
                <option key={category.id} value={category.id}>
                  {category.name}
                </option>
              ))}
            </select>
          </div>
          
          <div className="pt-4">
            <button 
              type="submit" 
              className="btn btn-primary w-full md:w-auto"
              disabled={loading}
            >
              {loading ? 'Kaydediliyor...' : 'Kategoriyi Kaydet'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}