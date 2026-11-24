import { useEffect, useState } from "react";
import { getProducts } from "../../api/products";
import "./Products.css";

const CATEGORY_LABELS = [
  "Procesor",
  "Motherboard",
  "RAM",
  "Kartelë grafike",
  "Disk",
  "Furnizues rryme",
  "Kasë",
];

export default function Products() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    getProducts()
      .then(setProducts)
      .catch((err) => setError(err.message))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <p className="status">Duke i ngarkuar produktet…</p>;
  if (error) return <p className="status error">Gabim: {error}</p>;
  if (products.length === 0) return <p className="status">S'ka produkte ende.</p>;

  return (
    <section className="products">
      <h1>Pjesët e kompjuterit</h1>
      <div className="product-grid">
        {products.map((product) => (
          <article key={product.id} className="product-card">
            <span className="product-category">
              {CATEGORY_LABELS[product.category]}
            </span>
            <h2>{product.name}</h2>
            <p className="product-brand">{product.brand}</p>
            <p className="product-price">{product.price.toFixed(2)} €</p>
            <p className={product.stock > 0 ? "in-stock" : "out-of-stock"}>
              {product.stock > 0 ? `Në stok: ${product.stock}` : "Pa stok"}
            </p>
          </article>
        ))}
      </div>
    </section>
  );
}
//Kur përdoruesi hap faqen, ky komponent i kërkon backend-it listën e produkteve aktive, 
// pret përgjigjen, dhe i shfaq si kartela: kategoria, emri, prodhuesi, çmimi dhe stoku.