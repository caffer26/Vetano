const API = "http://localhost:5173/api";

function mostrar(id) {

    document
        .querySelectorAll("section")
        .forEach(s => s.classList.add("hidden"));

    document
        .getElementById(id)
        .classList.remove("hidden");
}

async function carregarOwners() {

    const response = await fetch(`${API}/Owner`);

    const owners = await response.json();

    const tabela = document.getElementById("ownerTable");

    tabela.innerHTML = "";

    owners.forEach(owner => {

        tabela.innerHTML += `
            <tr>
                <td>${owner.name}</td>
                <td>${owner.email}</td>
                <td>${owner.cpf}</td>
                <td>${owner.phoneNumber}</td>
                <td>
                    <button onclick="excluirOwner('${owner.id}')">
                        Excluir
                    </button>
                </td>
                <td>
                    <button onclick="editarowner('${owner.id}')">
                        Editar
                    </button>
                </td>
            </tr>
        `;
    });
}

document
    .getElementById("ownerForm")
    .addEventListener("submit", async e => {

        e.preventDefault();

        const body = {
            name: document.getElementById("name").value,
            email: document.getElementById("email").value,
            cpf: document.getElementById("cpf").value,
            phoneNumber: document.getElementById("phoneNumber").value,
            birthDate: document.getElementById("birthDate").value
        };

        const response = await fetch(`${API}/Owner`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(body)
        });

        if (response.ok) {

            alert("Proprietário cadastrado");

            document
                .getElementById("ownerForm")
                .reset();

            carregarOwners();
        }
        else {
            const erro = await response.text();
            alert(erro);
        }
    });


async function editarOwner(id) {

    const response =
        await fetch(`${API}/Owner/${id}`);

    const owner =
        await response.json();

    document.getElementById("name").value =
        owner.name;

    document.getElementById("email").value =
        owner.email;

    document.getElementById("phoneNumber").value =
        owner.phoneNumber;

    ownerEditando = id;

    document
        .querySelector("#ownerForm button")
        .innerText = "Atualizar";
}

async function excluirOwner(id) {

    if (!confirm("Deseja excluir?"))
        return;

    const response = await fetch(`${API}/Owner/${id}`, {
        method: "DELETE"
    });

    if (response.ok) {
        carregarOwners();
    }
}

async function buscarPet() {

    const id = document.getElementById("petId").value;

    const response = await fetch(`${API}/Pet/${id}`);

    const resultado =
        document.getElementById("petResult");

    if (response.ok) {

        const pet = await response.json();

        resultado.textContent =
            JSON.stringify(pet, null, 2);
    }
    else {
        resultado.textContent = "Pet não encontrado";
    }
}

async function buscarAppointment() {

    const id =
        document.getElementById("appointmentId").value;

    const response =
        await fetch(`${API}/Appointment/${id}`);

    const resultado =
        document.getElementById("appointmentResult");

    if (response.ok) {

        const appointment =
            await response.json();

        resultado.textContent =
            JSON.stringify(appointment, null, 2);
    }
    else {
        resultado.textContent =
            "Agendamento não encontrado";
    }
}

carregarOwners();